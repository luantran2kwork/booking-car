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
export default class Default extends Component<iProps, iState> {
    constructor(props: any) {
        super(props);
        this.state = {};
    }

    _unsubscribe: any;

    async componentDidMount() {

        this._unsubscribe = this.props.navigation.addListener('focus', () => {
            this.LoadData();
        });

    }

    componentWillUnmount() {
        this._unsubscribe();
    }

    async LoadData() {
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
                    Title="Danh sách người dùng"
                    navigation={this.props.navigation}
                    HasDrawer={true}
                >
                    <View style={{ marginLeft: 15 }}>
                        <TouchableOpacity
                            activeOpacity={0.5}
                            onPress={() => {
                                this.props.navigation.navigate("AddNew")
                            }}
                        >
                            <FontAwesome5 name="plus" size={23} color="#FFFFFF" />
                        </TouchableOpacity>
                    </View>
                </Toolbar>
            </View>
        );
    }
}
