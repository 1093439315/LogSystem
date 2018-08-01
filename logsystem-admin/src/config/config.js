import Env from './env';

let config = {
    env: Env,
    cookieExpires: 1
};
export default config;

//菜单列表
let customMenuList=[
    {routeName:'home'},
    {routeName:'home',parent:''},
];

export const menuList=customMenuList;
