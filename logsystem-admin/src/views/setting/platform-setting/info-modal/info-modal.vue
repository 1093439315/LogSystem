<template>
    <m-modal v-model="infoModalShow" :title="title">
        <Form ref="infoData" :model="infoData" :rules="ruleValidate" :label-width="80">
            <FormItem label="平台名称" prop="name">
                <Input v-model="infoData.name" placeholder="输入平台名称"/>
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
            saveData() {
                return this.$store.state.platform.saveData;
            }
        },
        methods: {
            handleConfirmAdd() {
                alert('确认保存!');
            },
            handleCancel() {
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

<style scoped>
    .row {
        line-height: 28px;
        height: 28px;
    }
</style>
