<!--自定义模态框-->

<template>
    <div>
        <Modal v-model="infoModalShow">
            <p slot="header">
                <Icon type="md-add"/>
                <span>{{title}}</span>
            </p>

            <slot></slot>

            <div slot="footer">
                <Button @click="handleCancel">取消</Button>
                <Button type="primary" icon="md-checkmark" @click="handleConfirm">确定</Button>
            </div>

        </Modal>
    </div>
</template>

<script>
    export default {
        name: 'MModal',
        props: {
            value: {
                type: Boolean,
                default: false
            },
            title: '',
        },
        data() {
            return {
                infoModalShow: this.value
            };
        },
        methods: {
            handleCancel() {
                this.infoModalShow = false;
                this.$emit('on-cancel');
            },
            handleConfirm() {
                this.$emit('on-confirm');
            }
        },
        watch: {
            infoModalShow(newVal) {
                this.$emit('input', newVal);
                if (!newVal) this.$emit('on-cancel');
            },
            value(val) {
                this.infoModalShow = val;
            }
        }
    };
</script>

<style scoped>

</style>
