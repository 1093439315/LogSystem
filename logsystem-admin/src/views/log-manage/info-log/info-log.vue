<template>
    <div>
        <query-panel @on-query="handleQuery">
            <query></query>
        </query-panel>

        <br/>

        <Card>
            <tables ref="tables" searchable search-place="top"
                    v-model="tableData"
                    :columns="columns"
                    :loading="loading"
                    @on-delete="handleDelete">
            </tables>
            <br/>
            <!--<page :total="pagination.DataCount"-->
                  <!--:page-size="pagination.PageSize"-->
                  <!--:current="pagination.PageIndex"-->
                  <!--show-elevator show-sizer show-total-->
                  <!--@on-change="handlePageIndexChange"-->
                  <!--@on-page-size-change="handlePageSizeChange"></page>-->
        </Card>

    </div>
</template>

<script>

    import Tables from '_c/tables';
    import QueryPanel from '_s/query-panel';
    import Query from './query';
    import tableColumns from './table-columns';
    import {createNamespacedHelpers} from 'vuex';

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
            handleQuery() {
            },
            handleDelete() {
            }
        }
    };
</script>

<style scoped>

</style>
