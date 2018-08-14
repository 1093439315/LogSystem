import Env from './env';

let config = {
    env: Env,
    cookieExpires: 1
};
export default config;

//菜单列表
let customMenuList = [
    //系统设置-平台设置
    {name: 'platformSetting', parent: 'setting'},
    //系统设置-日志设置
    {name: 'logSetting', parent: 'setting'},
    //日志管理-info日志
    {name: 'infoLog', parent: 'logManage'},
    //日志管理-Error日志
    {name: 'errorLog', parent: 'logManage'},
];

export const menuListConfig = customMenuList;
