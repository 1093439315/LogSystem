<template>
    <div class="mlabel">
        <label>{{value}}</label>
    </div>
</template>

<script>
    export default {
        name: 'MLabel',
        props: {
            value: {
                type: String,
                default: ''
            }
        }
    };
</script>

<style scoped>
    .mlabel{
        font-family: "Helvetica Neue", Helvetica, "PingFang SC", "Hiragino Sans GB", "Microsoft YaHei", "微软雅黑", Arial, sans-serif;
        font-weight: bold;
        height: 10px;
        line-height: 10px;
        font-size: 12px;
        text-align: center;
    }
</style>
