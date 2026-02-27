const PlatformPage = {
    template: `
        <div style="padding-bottom:32px">
            <!-- Device Info -->
            <div class="section-header">📱 Device Information</div>
            <div class="card">
                <div class="info-grid">
                    <div class="info-item">
                        <div class="info-label">Platform</div>
                        <div class="info-value">{{ deviceInfo.platform }}</div>
                    </div>
                    <div class="info-item">
                        <div class="info-label">Browser</div>
                        <div class="info-value">{{ deviceInfo.browser }}</div>
                    </div>
                    <div class="info-item">
                        <div class="info-label">Screen</div>
                        <div class="info-value">{{ deviceInfo.screen }}</div>
                    </div>
                    <div class="info-item">
                        <div class="info-label">Language</div>
                        <div class="info-value">{{ deviceInfo.language }}</div>
                    </div>
                    <div class="info-item">
                        <div class="info-label">Pixel Ratio</div>
                        <div class="info-value">{{ deviceInfo.pixelRatio }}x</div>
                    </div>
                    <div class="info-item">
                        <div class="info-label">Touch</div>
                        <div class="info-value">{{ deviceInfo.touch }}</div>
                    </div>
                </div>
            </div>

            <!-- Connectivity -->
            <div class="section-header">🌐 Connectivity</div>
            <div class="card">
                <span class="status-badge" :class="isOnline ? 'status-online' : 'status-offline'">
                    {{ isOnline ? '● Online' : '● Offline' }}
                </span>
                <div v-if="connectionType" style="margin-top:8px;font-size:13px;color:var(--text-secondary)">
                    Connection: {{ connectionType }}
                </div>
            </div>

            <!-- Clipboard -->
            <div class="section-header">📋 Clipboard</div>
            <div class="card">
                <input type="text" v-model="clipText" placeholder="Text to copy..." />
                <div style="display:flex;gap:8px;margin-top:8px">
                    <button class="platform-btn" @click="copyToClipboard" style="flex:1">📋 Copy</button>
                    <button class="platform-btn" @click="pasteFromClipboard" style="flex:1;background:var(--success)">📌 Paste</button>
                </div>
                <div v-if="clipResult" class="result-text">{{ clipResult }}</div>
            </div>

            <!-- Share -->
            <div class="section-header">🔗 Share</div>
            <div class="card">
                <button class="platform-btn" @click="shareContent">
                    📤 Share this app
                </button>
            </div>

            <!-- Geolocation -->
            <div class="section-header">📍 Geolocation</div>
            <div class="card">
                <button class="platform-btn" @click="getLocation" :disabled="geoLoading">
                    {{ geoLoading ? 'Getting location...' : '📍 Get Current Location' }}
                </button>
                <div v-if="geoResult" class="result-text" style="margin-top:8px">{{ geoResult }}</div>
            </div>

            <!-- Preferences (LocalStorage) -->
            <div class="section-header">💾 Preferences Storage</div>
            <div class="card">
                <div class="pref-row">
                    <input type="text" v-model="prefKey" placeholder="Key" />
                    <input type="text" v-model="prefValue" placeholder="Value" />
                </div>
                <div style="display:flex;gap:8px;margin-top:8px">
                    <button class="platform-btn" @click="savePref" style="flex:1">Save</button>
                    <button class="platform-btn" @click="loadPref" style="flex:1;background:var(--success)">Load</button>
                    <button class="platform-btn" @click="deletePref" style="flex:1;background:var(--danger)">Delete</button>
                </div>
                <div v-if="prefResult" class="result-text" style="margin-top:8px">{{ prefResult }}</div>
            </div>

            <!-- Vibration -->
            <div class="section-header">📳 Vibration</div>
            <div class="card">
                <button class="platform-btn" @click="vibrate">
                    📳 Vibrate Device
                </button>
            </div>

            <!-- Camera -->
            <div class="section-header">📷 Camera</div>
            <div class="card">
                <div v-if="!cameraStream && !cameraError" style="text-align:center">
                    <button class="platform-btn" @click="startCamera">📷 Start Camera</button>
                </div>
                <div v-if="cameraError" class="result-text" style="color:var(--danger);margin-top:0">{{ cameraError }}</div>
                <div v-if="cameraStream">
                    <video ref="videoEl" autoplay playsinline muted
                           style="width:100%;border-radius:8px;background:#000;display:block"></video>
                    <div style="display:flex;gap:8px;margin-top:8px">
                        <button class="platform-btn" @click="takeSnapshot" style="flex:1;background:var(--success)">📸 Snapshot</button>
                        <button class="platform-btn" @click="stopCamera" style="flex:1;background:var(--danger)">⏹ Stop</button>
                    </div>
                </div>
                <canvas ref="snapshotCanvas" style="display:none"></canvas>
                <div v-if="snapshotUrl" style="margin-top:12px">
                    <img :src="snapshotUrl" style="width:100%;border-radius:8px;display:block" />
                    <div class="result-text">📸 Snapshot captured!</div>
                </div>
            </div>
        </div>
    `,
    setup() {
        const isOnline = ref(navigator.onLine);
        const connectionType = ref('');
        const clipText = ref('Hello from MAUI + Vue.js!');
        const clipResult = ref('');
        const geoLoading = ref(false);
        const geoResult = ref('');
        const prefKey = ref('myKey');
        const prefValue = ref('myValue');
        const prefResult = ref('');

        const deviceInfo = reactive({
            platform: navigator.platform || 'Unknown',
            browser: (() => {
                const ua = navigator.userAgent;
                if (ua.includes('Chrome')) return 'Chromium';
                if (ua.includes('Safari')) return 'WebKit';
                if (ua.includes('Firefox')) return 'Gecko';
                return 'Unknown';
            })(),
            screen: screen.width + ' × ' + screen.height,
            language: navigator.language,
            pixelRatio: window.devicePixelRatio || 1,
            touch: navigator.maxTouchPoints > 0 ? 'Yes' : 'No'
        });

        if (navigator.connection) {
            connectionType.value = navigator.connection.effectiveType || navigator.connection.type || '';
        }

        const onOnline = () => { isOnline.value = true; };
        const onOffline = () => { isOnline.value = false; };
        window.addEventListener('online', onOnline);
        window.addEventListener('offline', onOffline);

        const copyToClipboard = async () => {
            try {
                await navigator.clipboard.writeText(clipText.value);
                clipResult.value = '✅ Copied to clipboard!';
            } catch {
                clipResult.value = '❌ Clipboard access denied';
            }
        };

        const pasteFromClipboard = async () => {
            try {
                const text = await navigator.clipboard.readText();
                clipText.value = text;
                clipResult.value = '✅ Pasted from clipboard!';
            } catch {
                clipResult.value = '❌ Clipboard read denied';
            }
        };

        const shareContent = async () => {
            if (navigator.share) {
                try {
                    await navigator.share({ title: 'MAUI + Vue.js', text: 'Check out this app!', url: window.location.href });
                } catch { /* user cancelled */ }
            } else {
                alert('Web Share API not supported on this platform');
            }
        };

        const getLocation = () => {
            geoLoading.value = true;
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    (pos) => {
                        geoResult.value = 'Lat: ' + pos.coords.latitude.toFixed(6) + ', Lon: ' + pos.coords.longitude.toFixed(6) +
                            (pos.coords.altitude ? ', Alt: ' + pos.coords.altitude.toFixed(1) + 'm' : '');
                        geoLoading.value = false;
                    },
                    (err) => {
                        geoResult.value = '❌ ' + err.message;
                        geoLoading.value = false;
                    }
                );
            } else {
                geoResult.value = '❌ Geolocation not supported';
                geoLoading.value = false;
            }
        };

        const savePref = () => {
            if (prefKey.value) {
                localStorage.setItem(prefKey.value, prefValue.value);
                prefResult.value = '✅ Saved: ' + prefKey.value + ' = ' + prefValue.value;
            }
        };

        const loadPref = () => {
            const val = localStorage.getItem(prefKey.value);
            if (val !== null) {
                prefValue.value = val;
                prefResult.value = '✅ Loaded: ' + prefKey.value + ' = ' + val;
            } else {
                prefResult.value = '❌ Key not found: ' + prefKey.value;
            }
        };

        const deletePref = () => {
            localStorage.removeItem(prefKey.value);
            prefResult.value = '🗑️ Deleted: ' + prefKey.value;
        };

        const vibrate = () => {
            if (navigator.vibrate) {
                navigator.vibrate(200);
            } else {
                alert('Vibration API not supported on this platform');
            }
        };

        const videoEl = ref(null);
        const snapshotCanvas = ref(null);
        const cameraStream = ref(null);
        const cameraError = ref('');
        const snapshotUrl = ref('');

        const startCamera = async () => {
            cameraError.value = '';
            snapshotUrl.value = '';
            if (!navigator.mediaDevices?.getUserMedia) {
                cameraError.value = '❌ Camera API not supported on this platform';
                return;
            }
            try {
                const stream = await navigator.mediaDevices.getUserMedia({ video: { facingMode: 'environment' } });
                cameraStream.value = stream;
                await nextTick();
                if (videoEl.value) videoEl.value.srcObject = stream;
            } catch (err) {
                cameraError.value = '❌ ' + err.message;
            }
        };

        const stopCamera = () => {
            cameraStream.value?.getTracks().forEach(t => t.stop());
            cameraStream.value = null;
            if (videoEl.value) videoEl.value.srcObject = null;
        };

        const takeSnapshot = () => {
            if (!videoEl.value || !snapshotCanvas.value) return;
            const video = videoEl.value;
            const canvas = snapshotCanvas.value;
            canvas.width = video.videoWidth;
            canvas.height = video.videoHeight;
            canvas.getContext('2d').drawImage(video, 0, 0);
            snapshotUrl.value = canvas.toDataURL('image/jpeg', 0.85);
        };

        onUnmounted(() => {
            stopCamera();
            window.removeEventListener('online', onOnline);
            window.removeEventListener('offline', onOffline);
        });

        return {
            deviceInfo, isOnline, connectionType,
            clipText, clipResult, copyToClipboard, pasteFromClipboard,
            shareContent, getLocation, geoLoading, geoResult,
            prefKey, prefValue, prefResult, savePref, loadPref, deletePref,
            vibrate,
            videoEl, snapshotCanvas, cameraStream, cameraError, snapshotUrl,
            startCamera, stopCamera, takeSnapshot
        };
    }
};
