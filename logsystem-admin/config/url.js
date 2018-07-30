import env from './env';

const DEV_URL = 'http://localhost/MSH.LogSystem/';
const PRO_URL = 'https://produce.com';

export default env === 'development' ? DEV_URL : PRO_URL;
