import {formatDate} from '@/libs/tools';

const dateTimeFmt = 'yyyy-MM-dd HH:mm:ss';
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
        {title: '来源平台', type: 'index', align: 'center', key: 'Platform', sortable: true},
        {title: '业务位置', key: 'BusinessPosition', sortable: true},
        {title: '日志内容', key: 'Content', sortable: false},
        {title: '堆栈信息', key: 'TraceInfo', sortable: false},
        {
            title: '生成时间',
            key: 'CreationTime',
            sortable: true,
            render: (h, params) => {
                return h(
                    'div',
                    formatDate(params.row.CreationTime, dateTimeFmt)
                );
            }
        }
    ];
};

export default tableColumns;
