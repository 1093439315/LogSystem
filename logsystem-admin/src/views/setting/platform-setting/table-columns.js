let tableColumns = {};

tableColumns.columns = (vue) => {
    return [
        {
            type: 'selection',
            width: 60,
            align: 'center',
            key: 'selection',
            sortable: false
        },
        {title: '序号', type: 'index', align: 'center', key: 'index', sortable: false, width: 80},
        {title: '平台名称', key: 'Name', sortable: true},
        {title: 'AppId', key: 'AppId', sortable: true},
        {title: 'AppSecrect', key: 'AppSecrect', sortable: false},
        {title: '创建时间', key: 'CreatTime', sortable: true},
        {title: '最后更新时间', key: 'LastUpdateTime', sortable: true},
        {title: '最后更新者', key: 'LastUpdateBy'},
        {
            title: '启用',
            sortable: false,
            key: 'action',
            render: (h, params) => {
                return h(
                    'div',
                    vue.$refs.tables.$scopedSlots.action(params.row)
                );
            }
        }
    ];
};

export default tableColumns;
