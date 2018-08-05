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
        handleAdd(state) {
            return new Promise((resolve, reject) => {
                add(state.saveData).then(res => {
                    resolve();
                }).catch(err => {
                    reject(err);
                });
            });
        },
    }
};