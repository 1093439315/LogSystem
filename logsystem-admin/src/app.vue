<template>
    <div class="mainClass">
        <router-view></router-view>
    </div>
</template>
<script>
    export default {
        name: 'App',
        data() {
            return {};
        },
        mounted() {

        },
        beforeDestroy() {

        },
        methods: {}
    };
</script>

<style scoped>
    .mainClass{
        width: 100%;
        height: 100%;
        position: absolute;
        top: 0;
        bottom: 0;
        left: 0;
    }
</style>
