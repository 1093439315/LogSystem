import {add, query} from '@/api/platform';

export default {
    namespaced: true,
    state: {
        queryData: {},
        pagination: {},
        saveData: {},
        resultList: [],
    },
    mutations: {
        setQueryData(state, queryData) {
            console.log(queryData);
            state.queryData = queryData;
        },
        setPagination(state, pagination) {
            state.pagination = pagination;
        },
        setPageSize(state, pageSize) {
            console.log(pageSize);
            state.pagination.PageSize=pageSize;
        },
        setPageIndex(state, pageIndex) {
            state.pagination.PageIndex=pageIndex;
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
        handleStoreQuery(state, queryData) {
            return new Promise((resolve, reject) => {
                query(queryData).then(res => {
                    resolve(res);
                }).catch(err => {
                    reject(err);
                });
            });
        }
    }
};
