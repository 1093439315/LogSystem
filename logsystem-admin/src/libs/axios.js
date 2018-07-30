import Axios from 'axios';
import baseURL from '_conf/url';
import { Message } from 'iview';
import Cookies from 'js-cookie';
import { TOKEN_KEY } from '@/libs/util';
import  router from '@/router/routers';

class httpRequest {
    constructor () {
        this.options = {
            method: '',
            url: ''
        }
        // 存储请求队列
        this.queue = {}
    }

    // 销毁请求实例
    destroy (url) {
        delete this.queue[url]
        const queue = Object.keys(this.queue)
        return queue.length
    }

    // 请求拦截
    interceptors (instance, url) {
        // 添加请求拦截器
        instance.interceptors.request.use(config => {
            if (!config.url.includes('/users')) {
                config.headers['x-access-token'] = Cookies.get(TOKEN_KEY)
            }
            // Spin.show()
            // 在发送请求之前做些什么
            return config
        }, error => {
            // 对请求错误做些什么
            return Promise.reject(error)
        })

        // 添加响应拦截器
        instance.interceptors.response.use((res) => {

            let { data } = res;
            const is = this.destroy(url)
            if (!is) {
                setTimeout(() => {
                    // Spin.hide()
                }, 500)
            }

            //401 未登录
            if (res.status == 401) {
                Cookies.remove(TOKEN_KEY);
                Message.error(data.Message);
                //跳转到登录页
                router.go('/login');
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
                if (!data.Status){
                    Message.error(data.Message);
                    return false;
                }
                return data.Data;
            }

            return data;
        }, (error) => {
            Message.error('服务内部错误')
            // 对响应错误做点什么
            return Promise.reject(error)
        })
    }

    // 创建实例
    create () {
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
    request (options) {
        var instance = this.create();
        this.interceptors(instance, options.url);
        options = Object.assign({}, options);
        this.queue[options.url] = instance;
        return instance(options);
    }
}

export default httpRequest
