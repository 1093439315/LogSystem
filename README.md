# 欢迎使用“妙生活日志中心系统”

#### **项目介绍**

> 妙生活日志中心系统是上海妙尺商贸有限公司应对各种系统的日志集中式处理的解决方案，可以将多客户端、多系统的日志发送到日志处理中心服务器，对各个系统的日志进行集中式管理。

#### **使用前的准备**

1.**硬件准备**

 - Windows Server 2012 四核 8G 

2.**软件准备**

 - [RabbitMq（windows版本）](http://www.rabbitmq.com/news.html#2018-07-05T17:00:00+00:00)
 - [MongoDB（windows版本）](https://www.mongodb.com/download-center#enterprise)
 - .Net Framework 4.5.1

#### **软件架构**

>  [架构图](https://gitee.com/wuyuege/LogSystem/wikis/pages)


#### **安装教程**
>  [安装教程](https://gitee.com/wuyuege/LogSystem/wikis/pages?title=%E7%B3%BB%E7%BB%9F%E7%9A%84%E5%AE%89%E8%A3%85&parent=)
#### **使用说明**
1. 服务端配置用户后直接从管理端页面进入
2. 客户端使用：   
`MSHLogger.DefaultInfo("测试！");`    
或    
`MSHLogger.Instance("订单", "新建").Info("业务测试2");`   
具体用法请移步：

#### **参与贡献**

1. Fork 本项目
2. 新建 Feat_xxx 分支
3. 提交代码
4. 新建 Pull Request

#### **感谢以下开源项目**
[iview-admin](https://github.com/iview/iview-admin)   
[SuperSocket](https://github.com/kerryjiang/SuperSocket)
