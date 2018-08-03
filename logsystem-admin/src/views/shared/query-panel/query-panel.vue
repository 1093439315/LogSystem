<!--查询面板-->

<template>
    <Collapse v-model="value1">
        <Panel name="1" content="哈哈哈哈">
            查询条件
            <Icon type="ios-search"/>
            <p slot="content" style="margin: 5px 20px">
                <slot style="margin: 20px"></slot>
            </p>
        </Panel>
    </Collapse>
</template>

<script>
    export default {
        name: 'QueryPanel',
        data() {
            return {
                changeTitle: '关闭',
                value1: '1'
            };
        },
        methods: {
            toggleChange() {
                if (this.changeTitle === '关闭') {
                    this.$refs.queryContent.style.height = '100px';
                    this.changeTitle = '展开';
                }
                else {
                    this.$refs.queryContent.style.height = '0';
                    this.changeTitle = '关闭';
                }
            }
        }
    };
</script>

<style scoped>

</style>
