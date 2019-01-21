import { fetchUtils } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';

 const httpClient = (url, options = {}) => {
    if (!options.headers) {
        options.headers = new Headers({ Accept: 'application/json' });
    }
    const token = localStorage.getItem('token');
    options.headers.set('Authorization', `Bearer ${token}`);
    return fetchUtils.fetchJson(url, options);
  }
 export const dataProvider = jsonServerProvider('http://localhost:8050/api/', httpClient);
 export default dataProvider;