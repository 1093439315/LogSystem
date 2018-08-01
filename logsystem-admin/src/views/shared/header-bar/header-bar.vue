<template>
    <div class="header-bar">
        <!--左边侧边切换-->
        <sider-trigger :collapsed="collapsed" icon="md-menu" @on-change="handleCollpasedChange"></sider-trigger>
        <custom-bread-crumb show-icon style="margin-left: 30px;" :list="breadCrumbList"></custom-bread-crumb>
        <!--左侧面包屑导航-->
        <!--顶部右边内容-->
        <div class="custom-content-con">
            <slot></slot>
        </div>
    </div>
</template>

<script>
    import siderTrigger from './sider-trigger';
    import customBreadCrumb from './custom-bread-crumb';

    export default {
        name: 'HeaderBar',
        components: {
            siderTrigger,
            customBreadCrumb
        },
        props: {
            collapsed: Boolean
        },
        computed: {
            breadCrumbList() {
                console.log(this.$store.state.app.breadCrumbList);
                return this.$store.state.app.breadCrumbList;
            }
        },
        methods: {
            handleCollpasedChange(state) {
                this.$emit('on-coll-change', state);
            }
        }
    };
</script>

<style lang="less">
    @import './header-bar.less';
</style>
