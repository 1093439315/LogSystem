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

export const add = (saveData) => {
    const data = saveData;
    return axios.request({
        url: controller + 'Add',
        data,
        method: 'post'
    });
};
