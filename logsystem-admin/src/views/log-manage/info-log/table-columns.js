import {formatDate} from '@/libs/tools';

const dateTimeFmt = 'yyyy-MM-dd hh:mm:ss';
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
        {title: '序号', type: 'index', align: 'center', key: 'index', sortable: false, width: 50},
        {title: '来源平台', align: 'center', key: 'Platform', sortable: true, width: 120},
        {title: '请求Id', key: 'RequestId', sortable: true, width: 88},
        {title: '业务位置', key: 'BusinessPosition', sortable: true, width: 120},
        {title: '日志内容', key: 'Content', tooltip: true, sortable: false},
        {title: '堆栈信息', key: 'TraceInfo', tooltip: true, sortable: false},
        {
            title: '生成时间',
            key: 'CreationTime',
            sortable: true,
            render: (h, params) => {
                return h(
                    'div',
                    formatDate(params.row.CreationTime, dateTimeFmt)
                );
            },
            width: 220
        }
    ];
};

export default tableColumns;
