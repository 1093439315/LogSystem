import axios from '@/libs/api.request';

const controller = 'api/Platform/';

export const query = (queryData) => {
    const data = queryData;
    return axios.request({
        url: controller + 'Query',
        data,
        method: 'get'
    });
};
