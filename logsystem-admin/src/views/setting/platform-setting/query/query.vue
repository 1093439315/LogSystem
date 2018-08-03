<template>
    <div class="">
        <Row :gutter="16">
            <Col span="8">
                <Row class-name="row">
                    <Col span="5">
                        <label style="font-weight: bold">平台名称：</label>
                    </Col>
                    <Col span="12">
                        <Input v-model="queryData.platformName" placeholder="输入平台名称" clearable
                               style="width: 200px"/>
                    </Col>
                </Row>
            </Col>
            <Col span="12">

            </Col>
        </Row>

        <br>
        <Button type="primary" icon="ios-search" style="float: right" @click="search">查询</Button>
        <br>
    </div>
</template>

<script>
    import CollapsedMenu from '@/views/shared/side-menu/collapsed-menu';
    import MLabel from '_c/m-label';

    export default {
        name: 'Query',
        components: {
            CollapsedMenu,
            MLabel
        },
        data() {
            return {
                //查询条件数据
                queryData: {}
            };
        },
        methods: {
            search() {
                this.$emit('on-search-click', this.queryData);
            }
        }
    };
</script>

<style scoped>
    .row {
        line-height: 28px;
        height: 28px;
    }
</style>
