import {add} from '@/api/platform';

export default {
    state: {
        saveData: {},
    },
    mutations: {
        add(state) {
        }
    },
    actions: {
        // 添加操作
        handleConfirmAdd(state, saveData) {
            return new Promise((resolve, reject) => {
                add(saveData).then(res => {
                    resolve(res);
                }).catch(err => {
                    reject(err);
                });
            });
        },
    }
};
