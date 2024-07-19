// Define the cache name
const cacheName = 'blazor-cache-v1';

// Define the files to cache
const filesToCache = [
    '/',
    'index.html',
    'manifest.json',
    'css/app.css',
    'js/app.js',
    '_framework/blazor.boot.json',
    'Translations/cs.json',
    'Translations/en-US.json'
];

// Install the service worker and cache all necessary files
self.addEventListener('install', event => {
    console.log('Service Worker: Installing...');
    event.waitUntil(
        caches.open(cacheName)
            .then(cache => {
                console.log('Service Worker: Caching Files');
                return cache.addAll(filesToCache);
            })
            .then(() => self.skipWaiting())
    );
});

// Activate the service worker and remove old cache if necessary
self.addEventListener('activate', event => {
    console.log('Service Worker: Activating...');
    event.waitUntil(
        caches.keys().then(cacheNames => {
            return Promise.all(
                cacheNames.map(cache => {
                    if (cache !== cacheName) {
                        console.log('Service Worker: Clearing Old Cache');
                        return caches.delete(cache);
                    }
                })
            );
        }).then(() => self.clients.claim())
    );
});

// Intercept network requests and serve cached files if available
self.addEventListener('fetch', event => {
    event.respondWith(
        caches.match(event.request)
            .then(response => {
                return response || fetch(event.request);
            })
    );
});

// Listen for messages from the client to trigger a page reload
self.addEventListener('message', event => {
    if (event.data === 'SKIP_WAITING') {
        self.skipWaiting();
    }
});

// Check for updates to the service worker and reload the page if a new version is found
self.addEventListener('updatefound', () => {
    console.log('Service Worker: Update Found');
    self.skipWaiting();
});

// Handle the service worker update and reload the page
self.addEventListener('controllerchange', () => {
    console.log('Service Worker: Controller Changed');
    window.location.reload();
});
