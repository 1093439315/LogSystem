import env from './env';

// const DEV_URL = 'http://log.jiewit.com/';
//118.31.35.208
const DEV_URL = 'http://localhost/MSH.LogSystem/';
// const DEV_URL = 'http://118.31.35.208:1345/';
const PRO_URL = 'https://produce.com';

export default env === 'development' ? DEV_URL : PRO_URL;
