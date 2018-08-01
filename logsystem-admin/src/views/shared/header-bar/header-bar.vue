<template>
    <div class="header-bar">
        <!--左边侧边切换菜单的关闭和打开-->
        <sider-trigger :collapsed="collapsed" icon="md-menu" @on-change="handleCollpasedChange"></sider-trigger>
        <!--左侧面包屑导航-->
        <custom-bread-crumb show-icon style="margin-left: 30px;" :list="breadCrumbList"></custom-bread-crumb>
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
