<template>
    <div>
        <query-panel>
            <query @on-handleQuery-click="handleQuery"></query>
        </query-panel>

        <br/>

        <Row>
            <Col>
                <Button type="success" icon="md-add" @click="handleAdd">新 增</Button>
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

        <info-modal v-model="saveData" :show="infoModalShow" :add="add"
                    @on-hide="handleHide" @on-confirm="handleConfirm"></info-modal>

    </div>
</template>

<script>

    import {mapActions} from 'vuex';
    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import columns from './table-columns';
    import {query} from '@/api/platform';
    import InfoModal from './info-modal';
    import MModal from '_c/m-modal';

    export default {
        name: 'PlatformSetting',
        components: {
            QueryPanel,
            Query,
            Tables,
            InfoModal,
            MModal,
        },
        data() {
            return {
                value1: '1',
                columns: columns,
                tableData: [],
                queryData: {},
                infoModalShow: false,
                add: true,
                saveData: {}
            };
        },
        methods: {
            ...mapActions([
                'handleConfirmAdd'
            ]),
            handleDelete(params) {
                console.log(params);
            },
            handleQuery(queryData) {
                this.queryData = queryData;
                query(queryData).then(res => {
                    this.tableData = res.Data;
                });
            },
            //新增时显示模态框
            handleAdd() {
                this.infoModalShow = true;
            },
            handleHide() {
                this.infoModalShow = false;
            },
            //确定保存
            handleConfirm(validate, data) {
                if (validate) {
                    this.handleConfirmAdd(data).then(res => {
                        if (res.Status) {
                            this.infoModalShow = false;
                            this.handleQuery(this.queryData);
                        }
                    });
                }
            }
        },
        mounted() {
            this.handleQuery(this.queryData);
        }
    };
</script>

<style scoped>

</style>
