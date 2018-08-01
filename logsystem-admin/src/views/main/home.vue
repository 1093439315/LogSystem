<template>
    <div class="home">
        <Layout style="height: 100%">

            <!--左侧菜单栏-->
            <Sider hide-trigger collapsible :width="256" :collapsed-width="64" v-model="collapsed">

                <div class="logo-con">
                    <img v-show="!collapsed" :src="maxLogo" key="max-logo"/>
                    <img v-show="collapsed" :src="minLogo" key="min-logo"/>
                </div>

                <Menu theme="dark" v-show="!collapsed" :class="menuitemClasses">
                    <Submenu name="1" :class="menuitemClasses">
                        <template slot="title">
                            <Icon type="md-settings"/>
                            系统设置
                        </template>
                        <MenuItem name="1-1">
                            <Icon type="md-cloud-done"/>
                            平台设置
                        </MenuItem>
                        <MenuItem name="1-2">
                            <Icon type="md-shuffle"/>
                            日志设置
                        </MenuItem>
                    </Submenu>
                    <Submenu name="2" :class="menuitemClasses">
                        <template slot="title">
                            <Icon type="md-document"/>
                            系统日志
                        </template>
                        <MenuItem name="2-1">
                            <Icon type="ios-information-circle"/>
                            信息日志
                        </MenuItem>
                        <MenuItem name="2-2">
                            <Icon type="md-warning"/>
                            警告日志
                        </MenuItem>
                        <MenuItem name="2-3">
                            <Icon type="ios-close-circle"/>
                            错误日志
                        </MenuItem>
                        <MenuItem name="2-4">
                            <Icon type="ios-flask"/>
                            调试日志
                        </MenuItem>
                    </Submenu>
                </Menu>

            </Sider>

            <!--右边内容-->
            <Layout>

                <!--头部内容-->
                <Header class="header-con">
                    <header-bar :collapsed="collapsed" @on-coll-change="handleCollapsedChange"></header-bar>
                </Header>

                <!--内容-->
                <Content></Content>

            </Layout>

        </Layout>
    </div>
</template>

<script>

    import {mapMutations, mapActions} from 'vuex';
    import minLogo from '@/assets/images/logo-min.jpg';
    import maxLogo from '@/assets/images/logo.jpg';
    import HeaderBar from '../shared/header-bar';

    export default {
        name: 'Home',
        components: {
            HeaderBar
        },
        data() {
            return {
                collapsed: false,
                minLogo,
                maxLogo
            };
        },
        computed: {
            rotateIcon () {
                return [
                    'menu-icon',
                    this.collapsed ? 'rotate-icon' : ''
                ];
            },
            menuitemClasses () {
                return [
                    'menu-item',
                    this.collapsed ? 'collapsed-menu' : ''
                ]
            }
        },
        methods: {
            ...mapMutations([
                'setBreadCrumb'
            ]),
            handleCollapsedChange(state) {
                this.collapsed = state;
            },
        },
        watch: {
            '$route'(newRoute) {
                this.setBreadCrumb(newRoute.matched);
                // this.setTagNavList(getNewTagList(this.tagNavList, newRoute))
            }
        },
        mounted() {
            this.setBreadCrumb(this.$route.matched);
        }
    };
</script>

<style lang="less">
    @import "./home.less";
</style>
