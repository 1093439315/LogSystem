<style lang="less">
    @import './login.less';
</style>

<template>
    <div class="login" @keydown.enter="handleLogin">
        <div class="login-con">
            <Card icon="log-in" title="欢迎登录" :bordered="false">
                <div class="form-con">
                    <login-form @on-success-valid="handleSubmit"></login-form>
                    <p class="login-tip">输入任意用户名和密码即可</p>
                </div>
            </Card>
        </div>
    </div>
</template>

<script>
    import LoginForm from '_c/login-form';
    import {mapActions} from 'vuex';

    export default {
        name: 'login',
        components: {
            LoginForm
        },
        methods: {
            ...mapActions([
                'handleLogin'
            ]),
            handleSubmit({userName, password}) {
                this.handleLogin({userName, password}).then(res => {
                    //登录成功跳转到首页
                    let redirect = decodeURIComponent(this.$route.query.redirect || '/');
                    this.$router.push({
                        path: redirect ? redirect : '/',
                    });
                });
            }
        }
    };
</script>

<style scoped>

</style>
