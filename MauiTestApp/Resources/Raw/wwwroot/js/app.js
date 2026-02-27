const app = createApp({
    setup() {
        const route = VueRouter.useRoute();
        const pageTitle = computed(() => route.meta.title || 'MAUI Feature Showcase');
        return { pageTitle };
    }
});

app.use(router);
app.mount('#app');
