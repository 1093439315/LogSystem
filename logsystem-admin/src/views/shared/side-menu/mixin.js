import CommonIcon from '_c/common-icon';

export default {
    components: {
        CommonIcon
    },
    methods: {
        showTitle(item) {
            return ((item && item.title) || item.title || item.name);
        },
        showChildren(item) {
            return item.children && (item.children.length > 0);
        },
        getNameOrHref(item, children0) {
            return item.href ? `isTurnByHref_${item.href}` : (children0 ? item.children[0].name : item.name);
        }
    }
};
