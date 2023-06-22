import './App.css';

import wsSubscribe from './WsSubscription';
import sseSubscribe from './SseSubscription';

const urlParams = new URLSearchParams(window.location.search);
const subscriptionMode = urlParams.get('subscriptionMode');
if (!subscriptionMode) throw new Error('Make sure to specify subscriptionMode query parameter');

subscriptionMode === 'sse'
  ? sseSubscribe()
  : wsSubscribe();

function App() {
  return (
    <div>Demo bug when starting backend with persisted queries and subscribing with WebSockets to a subscribtion</div>
  );
}

export default App;
