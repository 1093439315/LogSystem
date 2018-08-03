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

        <table-result-panel>
            <Table :columns="columns1" :data="data1"></Table>
        </table-result-panel>
    </div>
</template>

<script>

    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import TableResultPanel from '_s/table-result-panel';

    export default {
        name: 'PlatformSetting',
        components: {
            QueryPanel,
            Query,
            TableResultPanel
        },
        data() {
            return {
                value1: '1',
                columns1: [
                    {
                        title: 'Name',
                        key: 'name'
                    },
                    {
                        title: 'Age',
                        key: 'age'
                    },
                    {
                        title: 'Address',
                        key: 'address'
                    }
                ],
                data1: [
                    {
                        name: 'John Brown',
                        age: 18,
                        address: 'New York No. 1 Lake Park',
                        date: '2016-10-03'
                    },
                    {
                        name: 'Jim Green',
                        age: 24,
                        address: 'London No. 1 Lake Park',
                        date: '2016-10-01'
                    },
                    {
                        name: 'Joe Black',
                        age: 30,
                        address: 'Sydney No. 1 Lake Park',
                        date: '2016-10-02'
                    },
                    {
                        name: 'Jon Snow',
                        age: 26,
                        address: 'Ottawa No. 2 Lake Park',
                        date: '2016-10-04'
                    }
                ]
            };
        }
    };
</script>

<style scoped>

</style>
