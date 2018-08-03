<template>
    <div>
        <query-panel>
            <query></query>
        </query-panel>

        <br/>

        <Row>
            <Col>
                <Button type="success">新 增</Button>
            </Col>
        </Row>

        <br/>

        <Card>
            <tables ref="tables" editable searchable search-place="top" v-model="tableData"
                    :columns="columns"
                    @on-delete="handleDelete"/>
        </Card>
    </div>
</template>

<script>

    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import columns from './table-columns';

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
                tableData: []
            };
        },
        methods: {
            handleDelete(params) {
                console.log(params);
            }
        },
        mounted() {
            // getTableData().then(res => {
                // this.tableData = res.data
            // });
        }
    };
</script>

<style scoped>

</style>
