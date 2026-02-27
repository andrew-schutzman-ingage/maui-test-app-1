const DataPage = {
    template: `
        <div style="padding-bottom:32px">
            <!-- Search -->
            <div class="card">
                <div class="search-wrapper">
                    <input type="text" class="search-input" v-model="search" placeholder="Search items..." />
                </div>
            </div>

            <!-- Refresh -->
            <div style="text-align:center;padding:8px">
                <button class="refresh-btn" @click="refresh" :disabled="refreshing">
                    {{ refreshing ? 'Refreshing...' : '↻ Pull to Refresh' }}
                </button>
            </div>

            <!-- Empty State -->
            <div v-if="filteredGroups.length === 0" class="card">
                <div class="empty-state">
                    <div class="emoji">🔍</div>
                    <p>No items found matching "{{ search }}"</p>
                </div>
            </div>

            <!-- Grouped Data -->
            <div v-for="group in filteredGroups" :key="group.category" class="card">
                <div class="group-header">{{ group.category }} ({{ group.items.length }})</div>
                <div v-for="item in group.items" :key="item.name" class="data-item">
                    <div class="data-avatar">{{ item.name.charAt(0) }}</div>
                    <div class="data-info">
                        <h4>{{ item.name }}</h4>
                        <p>{{ item.description }}</p>
                        <span class="category-badge">{{ item.category }}</span>
                    </div>
                    <button class="data-delete" @click="deleteItem(item)">✕</button>
                </div>
            </div>

            <div class="footer">{{ totalItems }} items across {{ filteredGroups.length }} categories</div>
        </div>
    `,
    setup() {
        const search = ref('');
        const refreshing = ref(false);

        const allItems = ref([
            { name: 'Alpine Mountains', description: 'Snow-capped peaks reaching into the clouds', category: 'Nature', imageUrl: 'mountain' },
            { name: 'Ocean Sunset', description: 'Golden light reflecting off calm waters', category: 'Nature', imageUrl: 'ocean' },
            { name: 'Forest Trail', description: 'A winding path through ancient trees', category: 'Nature', imageUrl: 'forest' },
            { name: 'Desert Dunes', description: 'Rolling sand dunes under a clear sky', category: 'Nature', imageUrl: 'desert' },
            { name: 'Tropical Beach', description: 'White sand and turquoise waters', category: 'Nature', imageUrl: 'beach' },
            { name: 'Golden Gate Bridge', description: 'Iconic suspension bridge in San Francisco', category: 'Architecture', imageUrl: 'bridge' },
            { name: 'Eiffel Tower', description: 'Wrought-iron lattice tower in Paris', category: 'Architecture', imageUrl: 'tower' },
            { name: 'Modern Skyscraper', description: 'Glass and steel reaching skyward', category: 'Architecture', imageUrl: 'skyscraper' },
            { name: 'Ancient Temple', description: 'Stone ruins from a bygone era', category: 'Architecture', imageUrl: 'temple' },
            { name: 'Gothic Cathedral', description: 'Pointed arches and stained glass', category: 'Architecture', imageUrl: 'cathedral' },
            { name: 'Electric Car', description: 'The future of sustainable transport', category: 'Technology', imageUrl: 'car' },
            { name: 'Smartphone', description: 'A pocket computer connecting the world', category: 'Technology', imageUrl: 'phone' },
            { name: 'Robot Arm', description: 'Precision automation in manufacturing', category: 'Technology', imageUrl: 'robot' },
            { name: 'Solar Panel', description: 'Harnessing energy from the sun', category: 'Technology', imageUrl: 'solar' },
            { name: 'Drone', description: 'Aerial photography and delivery', category: 'Technology', imageUrl: 'drone' },
            { name: 'Pasta Carbonara', description: 'Classic Italian comfort food', category: 'Food', imageUrl: 'pasta' },
            { name: 'Sushi Platter', description: 'Fresh fish and seasoned rice', category: 'Food', imageUrl: 'sushi' },
            { name: 'Chocolate Cake', description: 'Rich and decadent dessert', category: 'Food', imageUrl: 'cake' },
            { name: 'Fresh Salad', description: 'Crisp greens with vinaigrette', category: 'Food', imageUrl: 'salad' },
            { name: 'Artisan Coffee', description: 'Carefully roasted and brewed', category: 'Food', imageUrl: 'coffee' },
            { name: 'Jazz Concert', description: 'Live improvisation and smooth melodies', category: 'Entertainment', imageUrl: 'jazz' },
            { name: 'Movie Premiere', description: 'Red carpet and silver screen magic', category: 'Entertainment', imageUrl: 'movie' },
            { name: 'Art Exhibition', description: 'Contemporary works on display', category: 'Entertainment', imageUrl: 'art' },
            { name: 'Video Game', description: 'Interactive digital entertainment', category: 'Entertainment', imageUrl: 'game' },
            { name: 'Book Club', description: 'Sharing stories and perspectives', category: 'Entertainment', imageUrl: 'book' }
        ]);

        const filteredGroups = computed(() => {
            const q = search.value.toLowerCase();
            const filtered = q
                ? allItems.value.filter(i => i.name.toLowerCase().includes(q) || i.description.toLowerCase().includes(q) || i.category.toLowerCase().includes(q))
                : allItems.value;

            const groups = {};
            filtered.forEach(item => {
                if (!groups[item.category]) groups[item.category] = [];
                groups[item.category].push(item);
            });

            return Object.keys(groups).sort().map(cat => ({ category: cat, items: groups[cat] }));
        });

        const totalItems = computed(() => filteredGroups.value.reduce((sum, g) => sum + g.items.length, 0));

        const deleteItem = (item) => {
            const idx = allItems.value.indexOf(item);
            if (idx > -1) allItems.value.splice(idx, 1);
        };

        const refresh = () => {
            refreshing.value = true;
            setTimeout(() => { refreshing.value = false; }, 1500);
        };

        return { search, refreshing, filteredGroups, totalItems, deleteItem, refresh };
    }
};
