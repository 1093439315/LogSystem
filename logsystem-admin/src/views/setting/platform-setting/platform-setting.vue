<template>
    <div>
        <query-panel>
            <query></query>
        </query-panel>

        <Divider></Divider>
    </div>
</template>

<script>

    import QueryPanel from '_s/query-panel';
    import Query from './query';

    export default {
        name: 'PlatformSetting',
        components: {
            QueryPanel,
            Query
        },
        data() {
            return {
                value1: '1'
            };
        }
    };
</script>

<style scoped>

</style>
