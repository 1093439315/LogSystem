<template>
    <div class="user-avator-dropdown">
        <Dropdown @on-click="handleClick">
            <Avatar style="background-color: #87d068" :src="userAvator" icon="ios-person"/>
            <Icon :size="18" type="md-arrow-dropdown"></Icon>
            <DropdownMenu slot="list">
                <DropdownItem name="logout">退出登录</DropdownItem>
            </DropdownMenu>
        </Dropdown>
    </div>
</template>

<script>

    import {mapActions} from 'vuex';

    export default {
        name: 'User',
        props: {
            userAvator: {
                type: String,
                default: ''
            }
        },
        methods: {
            ...mapActions([
                'handleLogOut'
            ]),
            handleClick(name) {
                switch (name) {
                    case 'logout':
                        this.handleLogOut().then(() => {
                            this.$router.push({
                                name: 'login'
                            });
                        });
                        break;
                }
            }
        }
    };
</script>

<style lang="less">
    @import "./user";
</style>
