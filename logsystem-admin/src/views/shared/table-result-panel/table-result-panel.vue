<!--table结果面板-->

<template>
    <div>
        <Collapse v-model="value1">
            <Panel name="1">
                查询结果
                <Icon type="md-grid"/>
                <div slot="content" style="margin: 2px 0px;padding: 0">
                    <slot style="margin: 0"></slot>
                </div>
            </Panel>
        </Collapse>
    </div>
</template>

<script>
    export default {
        name: 'TableResultPanel',
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
