<template>
    <h1>hello world</h1>
</template>
<script>
    export default {
        name: 'LoginForm',
        props: {
            userNameRules: {
                type: Array,
                default: () => {
                    return [
                        {required: true, message: '账号不能为空', trigger: 'blur'}
                    ];
                }
            },
            passwordRules: {
                type: Array,
                default: () => {
                    return [
                        {required: true, message: '密码不能为空', trigger: 'blur'}
                    ];
                }
            }
        },
        data() {
            return {
                form: {
                    userName: 'super_admin',
                    password: ''
                }
            };
        },
        computed: {
            rules() {
                return {
                    userName: this.userNameRules,
                    password: this.passwordRules
                };
            }
        },
        methods: {
            handleSubmit() {
                this.$refs.loginForm.validate((valid) => {
                    if (valid) {
                        this.$emit('on-success-valid', {
                            userName: this.form.userName,
                            password: this.form.password
                        });
                    }
                });
            }
        }
    };
</script>
