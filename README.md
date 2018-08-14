# 安装教程

#### **一、安装RabbitMq**

 1. 由于RabbitMq 是基于Erlang语言开发的，所以需要安装[Erlang][1]
 2. [下载安装RabbitMq][2]
 3. 启动RabbitMq
 4. 由于安装步骤比较简单，具体详情可以自行[搜索][3]


----------


#### **二、安装MongoDb**

 1. [下载地址][4] 选择Windows版本下载安装
 2. 在安装过程中可以选中安装MongoDB Compass，这是mongodb的图形化管理端
 3. 开启MogoDb 的Windows服务，方便启动MongoDb
 4. 具体操作流程可以自行[搜索][5]，本文不详述


----------
#### **三、安装日志系统服务端**

 1. 克隆代码后，用Vs打开MSH.LogSystem
 2. Config的配置
 3. 编译MSH.Log.WindowsService
 4. 拷贝编译后的二进制文件到服务器目录，假设为"yourFlorder"
 5. 以管理员身份打开Cmd，使用命令安装服务：
     `cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319\  ` 
     `installutil.exe yourFlorder\MSH.Log.WindowsService.exe`
 6. 如果安装失败，自行查看文件夹内的日志，位置在Logs内
 7. 如果安装成功，可以在浏览器中输入地址：http://yourhost:yourport/swagger 打开服务端提供的所有Api接口文档

----------
#### **四、安装日志管理端**

 1. [安装Node][6]
 2. 使用cmd或者powershell：`cd logsystem-admin`
 3. `npm install`
 4. 开发环境：`npm run dev`
 5. 部署Windows生产环境：`npm run build` 然后将dist文件夹、index_p.html、favoicon.icon、Web.config一并复制到服务器IIS对应的站点目录并设置默认页面为index_p.html
 6. IIS安装rewrite:[rewirte][7]
 7. 启动IIS站点
    
----------
**到此为止，恭喜您，妙生活日志中心系统已经安装完毕，欢迎您的使用！**

  [1]: http://www.rabbitmq.com/download.html
  [2]: http://www.rabbitmq.com/news.html#2018-07-05T17:00:00+00:00
  [3]: https://cn.bing.com/search?q=Windows%20%E5%AE%89%E8%A3%85rabbitMq&go=%E6%8F%90%E4%BA%A4&qs=n&form=QBLH&sp=-1&pq=jsonp%E8%B7%A8%E5%9F%9F%E8%8E%B7%E5%8F%96cookie%E5%AE%9E%E4%BE%8B&sc=0-17&sk=&cvid=592A8BE0FE3C418A8CD8C83227BF97B8
  [4]: https://www.mongodb.com/download-center#enterprise
  [5]: https://cn.bing.com/search?q=Windows%20%E5%AE%89%E8%A3%85MongoDb&qs=n&form=QBRE&sp=-1&pq=windows%20%E5%AE%89%E8%A3%85mongodb&sc=0-17&sk=&cvid=AC45777F11C643A3AAB041BB49A029EC
  [6]: https://nodejs.org/en/
  [7]: https://www.iis.net/downloads/microsoft/url-rewrite