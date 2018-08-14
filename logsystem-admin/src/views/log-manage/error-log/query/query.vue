<template>
    <div class="">
        <Row :gutter="16">
            <Col span="8">
                <Row class-name="row">
                    <Col span="5">
                        <label style="font-weight: bold">平台名称：</label>
                    </Col>
                    <Col span="12">
                        <Input v-model="queryData.Name" placeholder="输入平台名称" clearable
                               style="width: 200px"/>
                    </Col>
                </Row>
            </Col>
            <Col span="12">

            </Col>
        </Row>

    </div>
</template>

<script>
    import {createNamespacedHelpers} from 'vuex';

    const {mapActions, mapState, mapMutations, mapGetters} = createNamespacedHelpers('infolog');

    export default {
        name: 'Query',
        components: {},
        data() {
            return {
                //查询条件数据
                queryData: {},
            };
        },
        methods: {
            ...mapMutations([
                'setQueryData'
            ]),
        },
        watch: {
            queryData: {
                handler(newValue, oldValue) {
                    this.setQueryData(newValue);
                },
                deep: true
            },
        },
    };
</script>

<style scoped>
    .row {
        line-height: 28px;
        height: 28px;
    }
</style>
