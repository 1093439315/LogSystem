import axios from '@/libs/api.request';

const controller = 'api/Vertification/';

export const login = ({userName, password}) => {
    const data = {
        userName,
        password
    };
    return axios.request({
        url: controller + 'Login',
        data,
        method: 'post'
    });
};
