<template>
    <m-modal v-model="infoModalShow" :title="title"
             @on-cancel="handleCancel"
             @on-confirm="handleConfirm">
        <Form ref="infoData" :model="infoData" :rules="ruleValidate" :label-width="80">
            <FormItem label="平台名称" prop="name">
                <Input v-model="infoData.name" placeholder="输入平台名称"/>
            </FormItem>
            <FormItem label="AppId">
                <Input v-model="infoData.appId" placeholder="输入AppId"/>
            </FormItem>
            <FormItem label="Secrect">
                <Input v-model="infoData.secrect" placeholder="输入Secrect"/>
            </FormItem>
        </Form>
    </m-modal>
</template>

<script>
    import MModal from '_c/m-modal';

    export default {
        name: 'InfoModal',
        components: {
            MModal
        },
        data() {
            return {
                infoModalShow: false,
                width: 600,
                infoData: {},
                ruleValidate: {
                    name: [
                        {required: true, message: '平台名称不能为空', trigger: 'blur'}
                    ],
                }
            };
        },
        props: {
            //绑定的值
            value: {
                type: Object,
                default: () => {
                    return {};
                },
            },
            //是否显示
            show: {
                type: Boolean,
                default: false,
            },
            //是否为新增
            add: {
                type: Boolean,
                default: true
            }
        },
        computed: {
            title() {
                return this.add ? '新建平台' : '更新平台';
            },
        },
        methods: {
            handleConfirm() {
                this.$refs['infoData'].validate((valid) => {
                    this.$emit('on-confirm', valid, this.infoData);
                });
            },
            handleCancel() {
                this.$refs['infoData'].resetFields();
            },
        },
        watch: {
            show(val) {
                this.infoModalShow = val;
            },
            infoModalShow(val) {
                if (!val) this.$emit('on-hide');
            },
            value: {
                handler(newValue, oldValue) {
                    this.infoData = newValue;
                },
                deep: true
            },
            infoData: {
                handler(newValue, oldValue) {
                    this.$emit('input', newValue);
                },
                deep: true
            }
        }
    };
</script>

