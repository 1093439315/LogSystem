<template>
    <div>
        <query-panel @on-query="handleQuery">
            <query></query>
        </query-panel>

        <br/>

        <Row>
            <Col>
                <Button type="success" icon="md-add" @click="handleAdd">新 增</Button>
                <!--<Button type="error" icon="md-close">删 除</Button>-->
            </Col>
        </Row>

        <br/>

        <Card>
            <tables ref="tables" search-place="top"
                    v-model="tableData"
                    :columns="columns"
                    :loading="loading"
                    @on-delete="handleDelete">
                <template slot="action" slot-scope="props">
                    <Switch :value="props.Disabled" @on-change="handleDisableChange(props)"/>
                </template>
            </tables>
            <br/>
            <page :total="pagination.DataCount"
                  :page-size="pagination.PageSize"
                  :current="pagination.PageIndex"
                  show-elevator show-sizer show-total
                  @on-change="handlePageIndexChange"
                  @on-page-size-change="handlePageSizeChange"></page>
        </Card>

        <info-modal v-model="saveData" :show="infoModalShow" :add="add"
                    @on-hide="handleHide" @on-confirm="handleConfirm"></info-modal>

    </div>
</template>

<script>

    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import tableColumns from './table-columns';
    import InfoModal from './info-modal';
    import MModal from '_c/m-modal';
    import {createNamespacedHelpers} from 'vuex';

    const {mapActions, mapMutations} = createNamespacedHelpers('platform');

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
                tableData: [],
                infoModalShow: false,
                add: true,
                saveData: {},
                //表格是否正在加载
                loading: false,
            };
        },
        computed: {
            columns() {
                return tableColumns.columns(this);
            },
            pagination() {
                let pagination = this.$store.state.platform.pagination;
                if (!pagination) return {DataCount: 0};
                return pagination;
            },
            queryData() {
                let query = this.$store.state.platform.queryData;
                query.Pagination = this.pagination;
                return query;
            }
        },
        methods: {
            ...mapActions([
                'handleConfirmAdd',
                'handleStoreQuery'
            ]),
            ...mapMutations([
                'setPagination',
                'setPageSize',
                'setPageIndex'
            ]),
            handleDelete(params) {
                console.log(params);
            },
            handleQuery() {
                this.loading = true;
                this.handleStoreQuery(this.queryData).then(res => {
                    this.tableData = res.Data.List;
                    this.setPagination(res.Data.Pagination);
                    this.loading = false;
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
            },
            handleDisableChange(props) {
                console.log(props);
            },
            handlePageIndexChange(pageIndex) {
                this.setPageIndex(pageIndex);
                this.handleQuery();
            },
            handlePageSizeChange(pageSize) {
                this.setPageIndex(1);
                this.setPageSize(pageSize);
                this.handleQuery();
            }
        },
        mounted() {
            this.handleQuery();
        }
    };
</script>

<style scoped>

</style>
