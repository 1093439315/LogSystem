<template>
    <div>
        <Layout>
            <!--左侧菜单栏-->
            <Sider collapsible :width="256" :collapsed-width="64" v-model="collapsed">
                <div class="logo-con">
                    <!--<img v-show="!collapsed" :src="maxLogo" key="max-logo"/>-->
                    <!--<img v-show="collapsed" :src="minLogo" key="min-logo"/>-->
                </div>
                <Menu active-name="1-2" theme="dark" width="auto" :class="menuitemClasses">
                    <MenuItem name="1-1">
                        <Icon type="ios-navigate"></Icon>
                        <span>Option 1</span>
                    </MenuItem>
                    <MenuItem name="1-2">
                        <Icon type="ios-search"></Icon>
                        <span>Option 2</span>
                    </MenuItem>
                    <MenuItem name="1-3">
                        <Icon type="ios-settings"></Icon>
                        <span>Option 3</span>
                    </MenuItem>
                </Menu>
            </Sider>

            <!--右边内容-->
            <Layout>
                <!--头部内容-->
                <Header></Header>
                <!--内容-->
                <Content></Content>
            </Layout>
        </Layout>
    </div>
</template>

<script>
    export default {
        name: 'home',
        components: {},
        data() {
            return {
                collapsed: false
            };
        },
        computed: {},
        methods: {},
        watch: {},
        mounted: {}
    };
</script>
