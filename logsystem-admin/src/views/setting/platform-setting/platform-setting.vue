<template>
    <div>
        <query-panel>
            <query @on-handleQuery-click="handleQuery"></query>
        </query-panel>

        <br/>

        <Row>
            <Col>
                <Button type="success" icon="md-add">新 增</Button>
                <Button type="error" icon="md-close">删 除</Button>
            </Col>
        </Row>

        <br/>

        <Card>
            <tables ref="tables" searchable search-place="top" v-model="tableData"
                    :columns="columns"
                    @on-delete="handleDelete">
            </tables>
        </Card>
    </div>
</template>

<script>

    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import columns from './table-columns';
    import {query} from '@/api/platform';

    export default {
        name: 'PlatformSetting',
        components: {
            QueryPanel,
            Query,
            Tables
        },
        data() {
            return {
                value1: '1',
                columns: columns,
                tableData: [],
                queryData: {}
            };
        },
        methods: {
            handleDelete(params) {
                console.log(params);
            },
            handleQuery(queryData) {
                console.log(queryData);
                this.queryData = queryData;
                query(queryData).then(res => {
                    this.tableData = res;
                });
            }
        },
        mounted() {
            this.handleQuery(this.queryData);
        }
    };
</script>

<style scoped>

</style>
