<template>
    <div class="home">
        <Layout style="height: 100%">

            <!--左侧菜单栏-->
            <Sider hide-trigger collapsible :width="220" :collapsed-width="64" v-model="collapsed">

                <side-menu accordion :active-name="$route.name" :collapsed="collapsed"
                           @on-select="turnToPage"
                           :menu-list="menuList">
                    <div class="logo-con">
                        <img v-show="!collapsed" :src="maxLogo" key="max-logo"/>
                        <img v-show="collapsed" :src="minLogo" key="min-logo"/>
                    </div>
                </side-menu>

            </Sider>

            <!--右边内容-->
            <Layout>

                <!--头部内容-->
                <Header class="header-con">
                    <header-bar :collapsed="collapsed" @on-coll-change="handleCollapsedChange">
                        <user :user-avator="userAvator"/>
                    </header-bar>
                </Header>

                <!--内容-->
                <Content>

                    <Layout>
                        <!--快速导航-->
                        <div class="tag-nav-wrapper">
                            <tags-nav :value="$route" @input="handleClick" :list="tagNavList"
                                      @on-close="handleCloseTag"/>
                        </div>

                        <!--内容的真正内容-->
                        <Content class="content-wrapper">
                            <keep-alive :include="cacheList">
                                <router-view/>
                            </keep-alive>
                        </Content>
                    </Layout>


                </Content>

            </Layout>

        </Layout>
    </div>
</template>

<script>

    import {mapMutations, mapActions} from 'vuex';
    import minLogo from '@/assets/images/logo-min.png';
    import maxLogo from '@/assets/images/logo.png';
    import HeaderBar from '../shared/header-bar';
    import TagsNav from '../shared/tags-nav';
    import User from '../shared/user';
    import SideMenu from '../shared/side-menu';
    import {getNewTagList, getNextName} from '@/libs/util';

    export default {
        name: 'Home',
        components: {
            HeaderBar,
            User,
            TagsNav,
            SideMenu
        },
        data() {
            return {
                collapsed: false,
                minLogo,
                maxLogo
            };
        },
        computed: {
            tagNavList() {
                return this.$store.state.app.tagNavList;
            },
            rotateIcon() {
                return [
                    'menu-icon',
                    this.collapsed ? 'rotate-icon' : ''
                ];
            },
            userAvator() {
                return this.$store.state.vertification.avatorImgPath;
            },
            cacheList() {
                return this.tagNavList.length ?
                    this.tagNavList.filter(item => !(item.meta && item.meta.notCache)).map(item => item.name) : [];
            },
            menuList() {
                return this.$store.getters.menuList;
            },
            menuitemClasses() {
                return [
                    'menu-item',
                    this.collapsed ? 'collapsed-menu' : ''
                ];
            }
        },
        methods: {
            ...mapMutations([
                'setBreadCrumb',
                'setTagNavList',
                'addTag'
            ]),
            turnToPage(name) {
                if (name.indexOf('isTurnByHref_') > -1) {
                    window.open(name.split('_')[1]);
                    return;
                }
                this.$router.push({
                    name: name
                });
            },
            handleCollapsedChange(state) {
                this.collapsed = state;
            },
            handleCloseTag(res, type, name) {
                const nextName = getNextName(this.tagNavList, name);
                this.setTagNavList(res);
                if (type === 'all')
                    this.turnToPage('home');
                else if (this.$route.name === name)
                    this.$router.push({name: nextName});
            },
            handleClick(item) {
                this.turnToPage(item.name);
            }
        },
        watch: {
            '$route'(newRoute) {
                this.setBreadCrumb(newRoute.matched);
                this.setTagNavList(getNewTagList(this.tagNavList, newRoute));
            }
        },
        mounted() {
            this.setTagNavList();
            this.addTag(this.$store.state.app.homeRoute);
            this.setBreadCrumb(this.$route.matched);
        }
    };
</script>

<style lang="less">
    @import "./home.less";
</style>
