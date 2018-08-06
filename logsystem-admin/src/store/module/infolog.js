import {query} from '@/api/infolog';

export default {
    namespaced: true,
    state: {
        queryData: {},
        pagination: {},
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
            state.pagination.PageSize = pageSize;
        },
        setPageIndex(state, pageIndex) {
            state.pagination.PageIndex = pageIndex;
        }
    },
    actions: {
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
