import React from 'react';
//import { Admin, Resource } from 'react-admin';
import jsonServerProvider from 'ra-data-json-server';
import { Admin, Resource } from 'react-admin';
import { ProductList ,ProductEdit,ProductCreate } from './products';
import { UsersList, UserEdit, UserCreate } from './users';
import UserIcon from '@material-ui/icons/Group';
import Dashboard from './Dashboard';
import authProvider from './authProvider';

const dataProvider = jsonServerProvider('http://localhost:8050/api/');
const App = () => (
  <Admin dashboard={Dashboard} dataProvider={dataProvider} authProvider={authProvider}>
      <Resource name="product" list={ProductList} edit={ProductEdit} create ={ProductCreate}  /> 
      <Resource name="users" list={UsersList}  edit={UserEdit} create={UserCreate}   icon={UserIcon}/>      
  </Admin>
);

export default App;
