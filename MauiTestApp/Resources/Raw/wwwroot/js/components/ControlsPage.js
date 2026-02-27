const ControlsPage = {
    template: `
        <div style="padding-bottom:32px">
            <!-- Button -->
            <div class="card">
                <div class="control-group">
                    <label>🔘 Button</label>
                    <div style="display:flex;gap:8px;flex-wrap:wrap">
                        <button class="btn" @click="btnCount++">Clicked {{ btnCount }} times</button>
                        <button class="btn btn-outline" @click="btnCount = 0">Reset</button>
                    </div>
                </div>
            </div>

            <!-- Entry (Text Input) -->
            <div class="card">
                <div class="control-group">
                    <label>✏️ Entry</label>
                    <input type="text" v-model="entryText" placeholder="Type something..." />
                    <div v-if="entryText" class="result-text">You typed: {{ entryText }}</div>
                </div>
            </div>

            <!-- Editor (Multiline) -->
            <div class="card">
                <div class="control-group">
                    <label>📝 Editor</label>
                    <textarea v-model="editorText" placeholder="Write a longer text..."></textarea>
                    <div v-if="editorText" class="result-text">{{ editorText.length }} characters</div>
                </div>
            </div>

            <!-- CheckBox -->
            <div class="card">
                <div class="control-group">
                    <label>☑️ CheckBox</label>
                    <div class="checkbox-row">
                        <input type="checkbox" id="cb1" v-model="checkA" />
                        <label for="cb1">Option A</label>
                    </div>
                    <div class="checkbox-row" style="margin-top:6px">
                        <input type="checkbox" id="cb2" v-model="checkB" />
                        <label for="cb2">Option B</label>
                    </div>
                    <div class="result-text">Selected: {{ [checkA && 'A', checkB && 'B'].filter(Boolean).join(', ') || 'None' }}</div>
                </div>
            </div>

            <!-- Switch -->
            <div class="card">
                <div class="control-group">
                    <label>🔀 Switch</label>
                    <div class="switch-row">
                        <input type="checkbox" role="switch" v-model="switchOn" style="width:40px;height:20px" />
                        <span>{{ switchOn ? 'ON' : 'OFF' }}</span>
                    </div>
                </div>
            </div>

            <!-- Slider -->
            <div class="card">
                <div class="control-group">
                    <label>🎚️ Slider</label>
                    <input type="range" v-model.number="sliderVal" min="0" max="100" />
                    <div class="progress-bar"><div class="progress-fill" :style="{width: sliderVal + '%'}"></div></div>
                    <div class="result-text">Value: {{ sliderVal }}</div>
                </div>
            </div>

            <!-- Stepper -->
            <div class="card">
                <div class="control-group">
                    <label>🔢 Stepper</label>
                    <div class="counter-row">
                        <button class="counter-btn" @click="stepperVal = Math.max(0, stepperVal - 1)">−</button>
                        <span class="counter-value">{{ stepperVal }}</span>
                        <button class="counter-btn" @click="stepperVal = Math.min(100, stepperVal + 1)">+</button>
                    </div>
                </div>
            </div>

            <!-- DatePicker -->
            <div class="card">
                <div class="control-group">
                    <label>📅 DatePicker</label>
                    <input type="date" v-model="dateVal" />
                    <div v-if="dateVal" class="result-text">Selected: {{ dateVal }}</div>
                </div>
            </div>

            <!-- TimePicker -->
            <div class="card">
                <div class="control-group">
                    <label>⏰ TimePicker</label>
                    <input type="time" v-model="timeVal" />
                    <div v-if="timeVal" class="result-text">Selected: {{ timeVal }}</div>
                </div>
            </div>

            <!-- Picker (Select) -->
            <div class="card">
                <div class="control-group">
                    <label>📋 Picker</label>
                    <select v-model="pickerVal">
                        <option value="">Choose a color...</option>
                        <option>Red</option>
                        <option>Green</option>
                        <option>Blue</option>
                        <option>Purple</option>
                        <option>Orange</option>
                    </select>
                    <div v-if="pickerVal" class="result-text">Selected: {{ pickerVal }}</div>
                </div>
            </div>

            <!-- ActivityIndicator -->
            <div class="card">
                <div class="control-group">
                    <label>⏳ ActivityIndicator</label>
                    <div style="display:flex;align-items:center;gap:12px">
                        <div class="spinner" v-if="showSpinner"></div>
                        <span v-else style="color:var(--success);font-weight:600">Done!</span>
                        <button class="btn btn-outline" @click="toggleSpinner" style="padding:8px 16px;font-size:13px">
                            {{ showSpinner ? 'Stop' : 'Start' }}
                        </button>
                    </div>
                </div>
            </div>

            <!-- ProgressBar -->
            <div class="card">
                <div class="control-group">
                    <label>📊 ProgressBar</label>
                    <div class="progress-bar"><div class="progress-fill" :style="{width: progressVal + '%'}"></div></div>
                    <div style="display:flex;gap:8px;margin-top:8px">
                        <button class="btn btn-outline" @click="progressVal = Math.max(0, progressVal - 10)" style="padding:8px 14px;font-size:13px">−10%</button>
                        <button class="btn btn-outline" @click="progressVal = Math.min(100, progressVal + 10)" style="padding:8px 14px;font-size:13px">+10%</button>
                        <button class="btn" @click="animateProgress" style="padding:8px 14px;font-size:13px">Animate</button>
                    </div>
                    <div class="result-text">Progress: {{ progressVal }}%</div>
                </div>
            </div>

            <!-- SearchBar -->
            <div class="card">
                <div class="control-group">
                    <label>🔍 SearchBar</label>
                    <div class="search-wrapper">
                        <input type="text" class="search-input" v-model="searchText" placeholder="Search items..." />
                    </div>
                    <div v-if="searchText" class="result-text">
                        Searching for: "{{ searchText }}" — {{ filteredItems.length }} results
                    </div>
                    <div v-for="item in filteredItems" :key="item" style="padding:6px 0;font-size:14px;border-bottom:1px solid var(--border)">
                        {{ item }}
                    </div>
                </div>
            </div>
        </div>
    `,
    setup() {
        const btnCount = ref(0);
        const entryText = ref('');
        const editorText = ref('');
        const checkA = ref(false);
        const checkB = ref(true);
        const switchOn = ref(false);
        const sliderVal = ref(50);
        const stepperVal = ref(5);
        const dateVal = ref('');
        const timeVal = ref('');
        const pickerVal = ref('');
        const showSpinner = ref(true);
        const progressVal = ref(30);
        const searchText = ref('');

        const searchItems = ['Apple', 'Banana', 'Cherry', 'Date', 'Elderberry', 'Fig', 'Grape', 'Honeydew', 'Kiwi', 'Lemon'];
        const filteredItems = computed(() => {
            if (!searchText.value) return searchItems;
            return searchItems.filter(i => i.toLowerCase().includes(searchText.value.toLowerCase()));
        });

        const toggleSpinner = () => { showSpinner.value = !showSpinner.value; };

        const animateProgress = () => {
            progressVal.value = 0;
            const timer = setInterval(() => {
                progressVal.value += 2;
                if (progressVal.value >= 100) clearInterval(timer);
            }, 30);
        };

        return {
            btnCount, entryText, editorText, checkA, checkB,
            switchOn, sliderVal, stepperVal, dateVal, timeVal,
            pickerVal, showSpinner, progressVal, searchText,
            filteredItems, toggleSpinner, animateProgress
        };
    }
};
