const columns = [
    {
        type: 'selection',
        width: 60,
        align: 'center',
        key: 'selection'
    },
    {title: '序号', type: 'index', align: 'center', key: 'index', sortable: true, width: 80},
    {title: '平台名称', key: 'Name', sortable: true},
    {title: '创建时间', key: 'CreatTime', sortable: true},
    {title: '最后更新时间', key: 'LastUpdateTime', sortable: true},
    {title: '最后更新者', key: 'LastUpdateBy'}
];

export default columns;
