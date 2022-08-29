import React, { Component } from "react";
import {
    Text,
    View,
    Alert,
    TouchableOpacity,
    ScrollView,
    Button,
    BackHandler,
    FlatList,
    StyleSheet,
    KeyboardAvoidingView,
    Image,
    Dimensions,
    ImageBackground,
    Keyboard,
    StatusBar,
} from "react-native";
import Toolbar from "../../components/Toolbar";
import SMX from "../../constants/SMX";
import { inject, observer } from "mobx-react";
import GlobalStore from "../../Stores/GlobalStore";
import FontAwesome5 from "react-native-vector-icons/FontAwesome5";
import GlobalCache from "../../Caches/GlobalCache";

const { width, height } = Dimensions.get("window");

interface iProps {
    navigation: any;
    GlobalStore: GlobalStore;
}

interface iState { }

@inject(SMX.StoreName.GlobalStore)
@observer
export default class Edit extends Component<iProps, iState> {
    constructor(props: any) {
        super(props);
        this.state = {};
    }

    _unsubscribe: any;

    async componentDidMount() {
        this._unsubscribe = this.props.navigation.addListener('focus', () => {
            this.setUpEditForm();
        });
    }

    componentWillUnmount() {
        this._unsubscribe();
    }

    async setUpEditForm() {
        try {
            this.props.GlobalStore.ShowLoading();

            //Xử lý dữ liệu

            this.props.GlobalStore.HideLoading();
        } catch (ex) {
            this.props.GlobalStore.Exception = ex;
            this.props.GlobalStore.HideLoading();
        }
    }

    //Hàm xử lý sự kiện lưu
    async saveData() {
        try {
            this.props.GlobalStore.ShowLoading();

            //Xử lý dữ liệu

            this.props.GlobalStore.HideLoading();
        } catch (ex) {
            this.props.GlobalStore.Exception = ex;
            this.props.GlobalStore.HideLoading();
        }
    }


    render() {
        return (
            <View style={{ flex: 1, backgroundColor: "#ebebfa" }}>
                <Toolbar
                    Title="Chỉnh sửa người dùng"
                    navigation={this.props.navigation}
                >
                </Toolbar>
            </View>
        );
    }
}
