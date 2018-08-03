import Axios from 'axios';
import baseURL from '_conf/url';
import {Message} from 'iview';
import Cookies from 'js-cookie';
import {TOKEN_KEY} from '@/libs/util';
import iView from 'iview';

class httpRequest {
    constructor() {
        this.options = {
            method: '',
            url: ''
        };
        // 存储请求队列
        this.queue = {};
    }

    // 销毁请求实例
    destroy(url) {
        delete this.queue[url];
        const queue = Object.keys(this.queue);
        return queue.length;
    }

    // 请求拦截
    interceptors(instance, url) {

        // 添加请求拦截器
        instance.interceptors.request.use(config => {
                if (!config.url.includes('/login')) {
                    config.headers[TOKEN_KEY] = Cookies.get(TOKEN_KEY);
                }
                return config;
            },
            error => {
                iView.LoadingBar.error();
                // 对请求错误做些什么
                return Promise.reject(error);
            });

        // 添加响应拦截器
        instance.interceptors.response.use((res) => {
                iView.LoadingBar.finish();
                const is = this.destroy(url);
                if (!is) {
                    setTimeout(() => {
                    }, 500);
                }
                return this.ProcessingResponse(res);
            },
            (error) => {
                iView.LoadingBar.error();
                let res = error.response;
                this.ProcessingResponse(res);
                // 对响应错误做点什么
                return Promise.reject(error);
            });
    }

    // 创建实例
    create() {
        let conf = {
            baseURL: baseURL,
            // timeout: 2000,
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'X-URL-PATH': location.pathname
            }
        };
        return Axios.create(conf);
    }

    // 请求实例
    request(options) {
        iView.LoadingBar.start();
        var instance = this.create();
        this.interceptors(instance, options.url);
        options = Object.assign({}, options);
        this.queue[options.url] = instance;
        return instance(options);
    }

    //处理响应数据
    ProcessingResponse(res) {
        if (!res) return false;
        let {data} = res;
        //401 未登录
        if (res.status == 401) {
            Cookies.remove(TOKEN_KEY);
            Message.error(data.Message);
            //跳转到登录页
            window.location.href = '/login';
            return false;
        }
        //501 自定义的错误
        if (res.status == 501) {
            Message.error(data.Message);
            return false;
        }
        //非200 其他错误
        if (res.status != 200) {
            Message.error(data.Message);
            return false;
        }
        //请求正常但是状态不对
        if (res.status == 200) {
            if (!data.Status) {
                Message.error(data.Message);
                return false;
            }
            return data.Data;
        }
        return data;
    }
}

export default httpRequest;
