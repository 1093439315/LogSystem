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
];

export const menuListConfig = customMenuList;
