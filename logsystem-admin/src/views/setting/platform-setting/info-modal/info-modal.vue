<template>
    <m-modal v-model="infoModalShow">
        <p>我是内容</p>
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
                infoModalShow: true,
                width: 600,
            };
        },
        methods: {
            handleConfirmAdd() {
                alert('确认保存!');
            },
            handleCancel() {
            }
        }
    };
</script>

<style scoped>

</style>
