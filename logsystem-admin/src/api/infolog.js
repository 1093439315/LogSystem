import axios from '@/libs/api.request';

const controller = 'api/InfoLog/';

export const query = (queryData) => {
    const data = queryData;
    return axios.request({
        url: controller + 'Query',
        params: data,
        method: 'get'
    });
};
