<template>
    <div>
        <Row :gutter="16">
            <Col span="12">
                <Row>
                    <Col><label>平台名称：</label></Col>
                    <Col>
                        <Input v-model="queryData.platformName" placeholder="输入平台名称" clearable
                               style="width: 200px"/>
                    </Col>
                </Row>
            </Col>
        </Row>

        <br>
        <Button type="primary" icon="ios-search" style="float: right" @click="search">查询</Button>
        <br>
    </div>
</template>

<script>
    export default {
        name: 'Query',
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

</style>
