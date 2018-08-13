<template>
    <div>
        <query-panel @on-query="handleQuery">
            <query></query>
        </query-panel>

        <br/>

        <Card>
            <tables ref="tables" search-place="top"
                    v-model="tableData"
                    :columns="columns"
                    :loading="loading"
                    @on-delete="handleDelete">
            </tables>
            <br/>
            <page :total="pagination.DataCount"
                  :page-size="pagination.PageSize"
                  :current="pagination.PageIndex"
                  show-elevator show-sizer show-total
                  @on-change="handlePageIndexChange"
                  @on-page-size-change="handlePageSizeChange"></page>
        </Card>

    </div>
</template>

<script>

    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import tableColumns from './table-columns';
    import {createNamespacedHelpers} from 'vuex';

    const {mapActions, mapMutations} = createNamespacedHelpers('infolog');

    export default {
        name: 'InfoLog',
        components: {
            QueryPanel,
            Query,
            Tables
        },
        data() {
            return {
                value1: '1',
                tableData: [],
                //表格是否正在加载
                loading: false,
            };
        },
        computed: {
            columns() {
                return tableColumns.columns(this);
            },
            pagination() {
                let pagination = this.$store.state.infolog.pagination;
                if (!pagination) return {DataCount: 0};
                return pagination;
            },
            queryData() {
                let query = this.$store.state.infolog.queryData;
                query.Pagination = this.pagination;
                return query;
            }
        },
        methods: {
            ...mapActions([
                'handleStoreQuery'
            ]),
            ...mapMutations([
                'setPagination',
                'setPageSize',
                'setPageIndex'
            ]),
            handleQuery() {
                this.loading = true;
                this.handleStoreQuery(this.queryData).then(res => {
                    this.tableData = res.Data.List;
                    this.setPagination(res.Data.Pagination);
                    this.loading = false;
                });
            },
            handleDelete() {
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
